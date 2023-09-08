using API_.NetFramework_Project.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace API_.NetFramework_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private static List<TaskTp> tasks = new List<TaskTp>
        {
            new TaskTp { Id = 1, Title = "Buy groceries", IsCompleted = false },
            new TaskTp { Id = 2, Title = "Read a book", IsCompleted = true }
        };

        [HttpGet]
        public ActionResult<IEnumerable<TaskTp>> GetTasks()
        {
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public ActionResult<TaskTp> GetTask(int id)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }

        [HttpGet("completed")]
        public ActionResult<IEnumerable<TaskTp>> GetCompletedTasks()
        {
            var completedTasks = tasks.Where(t => t.IsCompleted).ToList();
            return Ok(completedTasks);
        }

        [HttpGet("incomplete")]
        public ActionResult<IEnumerable<TaskTp>> GetIncompleteTasks()
        {
            var incompleteTasks = tasks.Where(t => !t.IsCompleted).ToList();
            return Ok(incompleteTasks);
        }

        [HttpPost]
        public ActionResult<TaskTp> CreateTask(TaskTp task)
        {
            task.Id = tasks.Max(t => t.Id) + 1;
            tasks.Add(task);
            return CreatedAtAction(nameof(GetTask), new { id = task.Id }, task);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTask(int id, TaskTp updatedTask)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task == null)
            {
                return NotFound();
            }

            task.Title = updatedTask.Title;
            task.IsCompleted = updatedTask.IsCompleted;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTask(int id)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task == null)
            {
                return NotFound();
            }

            tasks.Remove(task);
            return NoContent();
        }

        // New action methods added here

        [HttpGet("title/{id}")]
        public ActionResult<string> GetTitle(int id)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task == null)
            {
                return NotFound();
            }
            return Ok(task.Title);
        }

        [HttpGet("iscompleted/{id}")]
        public ActionResult<bool> GetIsCompleted(int id)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task == null)
            {
                return NotFound();
            }
            return Ok(task.IsCompleted);
        }
    }
}



//using API_.NetFramework_Project.Models;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace API_.NetFramework_Project.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class TaskController : ControllerBase
//    {
//        private static List<TaskTp> tasks = new List<TaskTp>
//        {
//            new TaskTp { Id = 1, Title = "Buy groceries", IsCompleted = false },
//            new TaskTp { Id = 2, Title = "Read a book", IsCompleted = true }
//        };

//        [HttpGet]
//        public ActionResult<IEnumerable<TaskTp>> GetTasks()
//        {
//            return Ok(tasks);
//        }

//        [HttpGet("{id}")]
//        public ActionResult<TaskTp> GetTask(int id)
//        {
//            var task = tasks.FirstOrDefault(t => t.Id == id);
//            if (task == null)
//            {
//                return NotFound();
//            }
//            return Ok(task);
//        }

//        [HttpGet("completed")]
//        public ActionResult<IEnumerable<TaskTp>> GetCompletedTasks()
//        {
//            var completedTasks = tasks.Where(t => t.IsCompleted).ToList();
//            return Ok(completedTasks);
//        }

//        [HttpGet("incomplete")]
//        public ActionResult<IEnumerable<TaskTp>> GetIncompleteTasks()
//        {
//            var incompleteTasks = tasks.Where(t => !t.IsCompleted).ToList();
//            return Ok(incompleteTasks);
//        }
//        [HttpPost]
//        public ActionResult<TaskTp> CreateTask(TaskTp task)
//        {
//            task.Id = tasks.Max(t => t.Id) + 1;
//            tasks.Add(task);
//            return CreatedAtAction(nameof(GetTask), new { id = task.Id }, task);
//        }

//        [HttpPut("{id}")]
//        public IActionResult UpdateTask(int id, TaskTp updatedTask)
//        {
//            var task = tasks.FirstOrDefault(t => t.Id == id);
//            if (task == null)
//            {
//                return NotFound();
//            }

//            task.Title = updatedTask.Title;
//            task.IsCompleted = updatedTask.IsCompleted;
//            return NoContent();
//        }

//        [HttpDelete("{id}")]
//        public IActionResult DeleteTask(int id)
//        {
//            var task = tasks.FirstOrDefault(t => t.Id == id);
//            if (task == null)
//            {
//                return NotFound();
//            }

//            tasks.Remove(task);
//            return NoContent();
//        }




//    }
//}








//using API_.NetFramework_Project.Models;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace API_.NetFramework_Project.Controllers

//{
//    [Route("api/[controller]")]

//    [ApiController]

//    public class TaskController : ControllerBase
//    {
//        private static List<TaskTp> tasks = new List<TaskTp>
//        {
//        new TaskTp { Id = 1, Title = "Buy groceries", IsCompleted = false },
//        new TaskTp { Id = 2, Title = "Read a book", IsCompleted = true }
//        };

//        [HttpGet]
//        public ActionResult<IEnumerable<Task>> GetTasks()
//        {
//            return Ok(tasks);
//        }

//        [HttpGet("{id}")]
//        public ActionResult<Task> GetTask(int id)
//        {
//            var task = tasks.FirstOrDefault(t => t.Id == id);
//            if (task == null)
//            {
//                return NotFound();
//            }
//            return Ok(task);
//        }

//        [HttpPost]
//        public ActionResult<Task> CreateTask(Task task)
//        {
//            TaskTp.Id = tasks.Max(t => t.Id) + 1;
//            tasks.Add(TaskTp);
//            return CreatedAtAction(nameof(GetTask), new { id = task.Id }, task);
//        }

//        [HttpPut("{id}")]
//        public IActionResult UpdateTask(int id, Task updatedTask)
//        {
//            var task = tasks.FirstOrDefault(t => t.Id == id);
//            if (task == null)
//            {
//                return NotFound();
//            }

//            task.Title = updatedTask.Title;
//            task.IsCompleted = updatedTask.IsCompleted;
//            return NoContent();
//        }

//        [HttpDelete("{id}")]
//        public IActionResult DeleteTask(int id)
//        {
//            var task = tasks.FirstOrDefault(t => t.Id == id);
//            if (task == null)
//            {
//                return NotFound();
//            }

//            tasks.Remove(task);
//            return NoContent();
//        }


//    }
//}
