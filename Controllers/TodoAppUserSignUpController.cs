using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using TaskApiV1.DBData;
using TaskApiV1.Models.BuisnessModels;
using TaskApiV1.Models.DTO;
using TaskApiV1.Models.Properties;

namespace TaskApiV1.Controllers
{
    [Route("api/TodoappLogin")]
    [ApiController]
    public class TodoAppUserSignUpController : ControllerBase
    {
        private AppDbContext _dbContext;
        private IMapper _mapper;

        public TodoAppUserSignUpController(AppDbContext dbContext,IMapper mapper)
        {
            _dbContext = dbContext;  
            _mapper = mapper;
        }

        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Consumes("application/json")]
        [HttpPost("Signin")]
        public ActionResult Signup(TodoUserSignupCreate signupCreate)
        {
            try
            {
                if (signupCreate == null || !ModelState.IsValid)
                {
                    return BadRequest();
                }

                if (_dbContext.TodoUserSignupsFormat.Any(x => x.Email == signupCreate.Email.ToLower()))
                {
                    var modelstate = new ModelStateDictionary();
                    modelstate.AddModelError("Email", "Provided email is already available");
                    return BadRequest(modelstate);
                }

                var usrgenglbhlp = new UsersRegisterGlobalHelper();

                usrgenglbhlp.CreatePasswordHash(signupCreate.Password);

                var usrsignupfor = new TodoUserSignupFormat()
                {
                    Email = signupCreate.Email.ToLower(),
                    PasswordHash = usrgenglbhlp.PasswordHash,
                    PasswordSalt = usrgenglbhlp.PasswordSalt,
                    VeificationToken = usrgenglbhlp.CreateVerificationToken(),
                    
                };
                _dbContext.TodoUserSignupsFormat.Add(usrsignupfor);
                _dbContext.SaveChanges();
                return Ok(new {EmailAddress = usrsignupfor.Email,
                    Password= signupCreate.Password,
                    VerificationToken = usrsignupfor.VeificationToken}
                );
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Consumes("application/json")]
        [HttpPut("Verification")]
        public ActionResult VerifyUserSignup(TodoUserSignupVerify userSignupVerify)
        {
            if(userSignupVerify == null || !ModelState.IsValid)
                return BadRequest(ModelState);

            var usr =  _dbContext.TodoUserSignupsFormat.Where(x=>x.Email == userSignupVerify.Email)
                .Select( x => new TodoUserSignupFormat
                {
                    UserId = x.UserId,
                    Email = x.Email,
                    PasswordHash = x.PasswordHash,
                    PasswordSalt= x.PasswordSalt,
                    Createdon = x.Createdon,
                }).FirstOrDefault();

            if(usr == null)
                return NotFound("Invalid Credentials");

            var usrgenglbhlp = new UsersRegisterGlobalHelper(salt:usr.PasswordSalt,hash: usr.PasswordHash);

            if (!usrgenglbhlp.VerifyPasswordHash(userSignupVerify.Password))
                return NotFound("Invalid Credentials");
            
            if (DateTime.Now > usr.Createdon.AddMinutes(20))
                return BadRequest("Verfication Token Expired");

            usr.VeificationToken = userSignupVerify.VerificationToken;
            usr.Verifiedon = DateTime.Now;
            usr.Active = 1;
            _dbContext.TodoUserSignupsFormat.Update(usr);
            _dbContext.SaveChanges();
            return Ok("User Verfied and Activated");
        }

        [HttpGet]
        public ActionResult<IEnumerable<TodoUserSignupFormat>> GetUsersList()
        {
            return _dbContext.TodoUserSignupsFormat.Select(x=> new TodoUserSignupFormat
            {
                Email= x.Email,
                UserId = x.UserId,
                Active = x.Active,
                Createdon = x.Createdon.Date
            }).ToList();
        }
    }
}
