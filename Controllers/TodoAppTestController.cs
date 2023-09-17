using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using TaskApiV1.DBData;
using TaskApiV1.Models.DTO;
using TaskApiV1.Models.Properties;

namespace TaskApiV1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoAppTestController : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _Mapper;

        public TodoAppTestController(AppDbContext dbContext,IMapper mapper)
        {
            _dbContext = dbContext;
            _Mapper = mapper;
        }

        [Route("CreateTask")]
        [HttpPost]
        [Consumes("application/json")]
        public IActionResult PostTodoTest(TodoTestcreate todo)
        {
           if(todo == null)
           {
                return BadRequest("No data present");
           }

          var todocreate=  _Mapper.Map<TestTodoAppFormat>(todo);

            _dbContext.TestTodoAppFormats.Add(todocreate);
            _dbContext.SaveChanges();

            return Ok();

        }

        [Route("UpdateTask")]
        [HttpPut]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult UpdateTodoTest([FromQuery][Range(1,int.MaxValue)] int TaskId,[FromBody]TodoTestUpdate todo)
        {
            if (todo == null)
            {
                return BadRequest("No data present");
            }
            var todos =  _dbContext.TestTodoAppFormats.Where(x=>x.TaskId == TaskId).FirstOrDefault<TestTodoAppFormat>();
            if(todos != null)
            {
                var todoupdate = _Mapper.Map(todo,todos);
                _dbContext.Update(todoupdate);
                _dbContext.SaveChanges();
                return Ok();
            }
            return NotFound("");
        }

        [Route("GetAllTasks")]
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<TestTodoAppFormat>>  GetAllTodoTest()
        {
            var testlst = _dbContext.TestTodoAppFormats.ToList();
            if(testlst != null && testlst.Count > 0)
            {
               var todomapget= _Mapper.Map<List<TodoTestGet>>(testlst);
               return Ok(todomapget);
            }
            return NoContent();
        }

        [Route("GetSingleTask/{TaskId:int}")]
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<TestTodoAppFormat> GetTodoTestById(int TaskId)
        {
          var todo =  _dbContext.TestTodoAppFormats.Find(TaskId);
            if (todo == null)
                return NotFound("given id is not registerd");
            var todomapget = _Mapper.Map<TodoTestGet>(todo);
            return Ok(todomapget);

        }

        [Route("GetUserTaskslist/{UserId:int}")]
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<TestTodoAppFormat>> GetTodoTestByUserId(int UserId)
        {
            if (UserId > 1000 && _dbContext.TodoUsersProfileAppFormats.Any(x => x.UserId == UserId))
            {
                var todo = _dbContext.TestTodoAppFormats.Where(x => x.UserId == UserId).ToList();
                if (todo != null && todo.Count > 0)
                {
                    var todomapget = _Mapper.Map<List<TodoTestGet>>(todo);
                    return Ok(todomapget);
                }
                return NotFound("User does not have a Tasks");
            }
            return NotFound("User not Registered");
        }

        [Route("DeleteTask/{TaskId:int}")]
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteTodoTest(int TaskId)
        {
            var todo = _dbContext.TestTodoAppFormats.Find(TaskId);
            if (todo == null)
                return NotFound("given id is not registerd");
            _dbContext.TestTodoAppFormats.Remove(todo);
            _dbContext.SaveChanges();
            return NoContent();
        }

    }
}
