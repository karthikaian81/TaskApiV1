using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskApiV1.DBData;
using TaskApiV1.Models.DTO;
using TaskApiV1.Models.Properties;

namespace TaskApiV1.Controllers
{
    [Route("api/Users")]
    [ApiController]
    public class TodoAppUsersController : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _Mapper;

        public TodoAppUsersController(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _Mapper = mapper;
        }

        [Route("CreateNewUser")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public ActionResult CreateUser(TodoUserCreate userCreate)
        {
           if(userCreate != null)
           {
              var newuser =  _Mapper.Map<TodoUsersAppFormat>(userCreate);
              _dbContext.TodoUsersAppFormats.Add(newuser);
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
        public ActionResult UpdateUser(int UserId,TodoUserUpdate userUpdate)
        {
            if (UserId > 1000 && _dbContext.TodoUsersAppFormats.Any(x=> x.UserId == UserId && x.Active == 1))
            {
                if (userUpdate != null)
                {
                    var user = _dbContext.TodoUsersAppFormats.Find(UserId);
                    var updateduser = _Mapper.Map(userUpdate, user);
                    _dbContext.TodoUsersAppFormats.Update(updateduser);
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
        public ActionResult DeleteUser(int UserId)
        {
            if (UserId > 1000 && _dbContext.TodoUsersAppFormats.Any(x => x.UserId == UserId && x.Active == 1))
            {
                var user = _dbContext.TodoUsersAppFormats.Find(UserId);
                user.Active = 0;
                _dbContext.TodoUsersAppFormats.Update(user);
                _dbContext.SaveChanges();
                return Ok();
            }
            return NotFound("UserId Not Found");
        }


        [Route("GetAllUsersDetails")]
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
       // [ProducesErrorResponseType(typeof(NoContentResult))]
        public ActionResult GetAllUsersList() 
        { 
            var Userslist = _dbContext.TodoUsersAppFormats.Where(x=>x.Active == 1).ToList();
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
            var Userslist = _dbContext.TodoUsersAppFormats.ToList();
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
          var test =   _dbContext.TodoUsersAppFormats
                .Join(_dbContext.TestTodoAppFormats,
                x => x.UserId,
                y => y.UserId,
                (x, y) => new {id=x.UserId, UserName = x.UserLoginName, TaskName = y.Title,
                    Description = y.Description ?? "No Descritption",LastLogin =x.Lastlogindate 
                }).OrderBy(x=>x.id)
                .ToList();
            return Ok(test);
        }

        public ActionResult GetUsersRoles() 
        { 
        
        
        }

    }
}
