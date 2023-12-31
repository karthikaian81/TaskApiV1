﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using TaskApiV1.DBData;
using TaskApiV1.Models.DTO;
using TaskApiV1.Models.Properties;
using System.Text;

namespace TaskApiV1.Controllers
{
    [Authorize]
    [Route("api/Users")]
    [ApiController]
    public class TodoAppUsersController : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _Mapper;

        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public TodoAppUsersController(AppDbContext dbContext, IMapper mapper,
             UserManager<IdentityUser> userManager,
              RoleManager<IdentityRole> roleManager,
            IConfiguration configuration)
        {
            _dbContext = dbContext;
            _Mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        [Route("CreateProfile")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public ActionResult CreateUserProfile(TodoUserCreate userCreate)
        {
            var usersign = _dbContext.TodoUserSignupsFormat.AsNoTracking().Where(x => x.Email == userCreate.UserEmail && x.Active == 1).FirstOrDefault();//.Select(y=> new { y.UserId, y.Email }).FirstOrDefault();
            if (usersign == null)
                return BadRequest("Invalid Credentials");
            if (userCreate != null)
            {
              var newuser =  _Mapper.Map<TodoUsersAppFormat>(userCreate);
                newuser.UserId = usersign.UserId;
              _dbContext.TodoUsersProfileAppFormats.Add(newuser);
              _dbContext.SaveChanges();
              return StatusCode(StatusCodes.Status201Created,userCreate);
            }
           return BadRequest();
        }

        [Route("[action]/{UserId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Consumes("application/json")]
        [HttpPut]
        public ActionResult UpdateUserProfile(int ProfileId,int UserId,TodoUserUpdate userUpdate)
        {
            var userprofile = _dbContext.TodoUsersProfileAppFormats.Where(x => x.UserId == UserId && x.Active == 1 && x.ProfileId == ProfileId).SingleOrDefault();
            if (UserId > 1000 && userprofile is not null)//_dbContext.TodoUsersProfileAppFormats.Any(x=> x.UserId == UserId && x.Active == 1))
            {
                if (userUpdate != null)
                {
                    //var user = _dbContext.TodoUsersProfileAppFormats.Find(UserId);
                    var updateduser = _Mapper.Map(userUpdate, userprofile);
                    _dbContext.TodoUsersProfileAppFormats.Update(updateduser);
                    _dbContext.SaveChanges();
                    return Ok();
                }
                return BadRequest();
            }
           return NotFound("UserId Not Found");
        }

        [Route("[action]/{UserId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Consumes("application/json")]
        [HttpDelete]
        public ActionResult DeleteUserProfile(int UserId)
        {
            if (UserId > 1000 && _dbContext.TodoUsersProfileAppFormats.Any(x => x.UserId == UserId && x.Active == 1))
            {
                var user = _dbContext.TodoUsersProfileAppFormats.Find(UserId);
                user.Active = 0;
                _dbContext.TodoUsersProfileAppFormats.Update(user);
                _dbContext.SaveChanges();
                return Ok();
            }
            return NotFound("UserId Not Found");
        }

        [Route("GetUsersDeatilsbyProfile")]
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult GetUsersDetailsbyProfileid(int ProfileId)
        {
            var Userslist = _dbContext.TodoUsersProfileAppFormats.Where(x => x.Active == 1 && x.ProfileId == ProfileId).SingleOrDefault();
            if (Userslist != null)
            {
                return Ok(_Mapper.Map<TodoUserGet>(Userslist));
                // return Ok(Userslist);
            }
            return NoContent();
        }

        [Route("GetUsersDeatilsbyUserid")]
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult GetUsersDetailsbyProfileidUserId(int UserId)
        {
            var Userslist = _dbContext.TodoUsersProfileAppFormats.Where(x => x.Active == 1 && x.UserId == UserId ).ToList();
            if (Userslist != null)
            {
                return Ok(_Mapper.Map<List<TodoUserGet>>(Userslist));
                // return Ok(Userslist);
            }
            return NoContent();
        }


        [Route("GetAllUsersDetails")]
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        // [ProducesErrorResponseType(typeof(NoContentResult))]
        public ActionResult GetAllUsersList() 
        { 
            var Userslist = _dbContext.TodoUsersProfileAppFormats.Where(x=>x.Active == 1).ToList();
            if (Userslist != null)
            {
                return Ok(_Mapper.Map<List<TodoUserGet>>(Userslist));
               // return Ok(Userslist);
            }
            return NoContent();
        }
        [Route("GetAllUsersDetailsMaster")]
        [HttpGet]
        public ActionResult GetAllUserList()
        {
            var Userslist = _dbContext.TodoUsersProfileAppFormats.ToList();
            if (Userslist != null)
            {
                return Ok(_Mapper.Map<List<TodoUserGet>>(Userslist));
                // return Ok(Userslist);
            }
            return NoContent();
        }
        [Route("GetAllUsersTaskDetails")]
        [HttpGet]
        public ActionResult GetAllusersTasklist()
        {
          var test =   _dbContext.TodoUsersProfileAppFormats
                .Join(_dbContext.TestTodoAppFormats,
                x => x.UserId,
                y => y.UserId,
                (x, y) => new {id= x.UserId, UserName = x.UserLoginName, TaskName = y.Title,
                    Description = y.Description ?? "No Descritption",LastLogin =x.Lastlogindate 
                }).OrderBy(x=>x.id)
                .ToList();
            return Ok(test);
        }

        [AllowAnonymous]
        [HttpPost("[action]")]
        public ActionResult Login(TodoUserLogin userLogin)
        {
            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(
                    new JwtSecurityToken(
                        //issuer: _configuration["JWT:ValidIssuer"],
                        //audience: _configuration["JWT:ValidAudience"],
                        claims: new List<Claim>() { new Claim("Name", "Karthik"), },
                        expires: DateTime.Now.AddMinutes(4),
                        signingCredentials: new SigningCredentials(
                            new SymmetricSecurityKey(
                                Encoding.UTF8.GetBytes(_configuration.GetSection("JWT:Secret").Value ?? "")
                                )
                            , SecurityAlgorithms.HmacSha512Signature),
                        notBefore: DateTime.Now.AddMinutes(2)
                        
                ))
            });
        }

        
    }
}
