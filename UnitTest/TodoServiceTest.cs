using Data;
using Data.Entities;
using Infrastructure.Dto;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using System;
using System.Linq;
using System.Net.Mime;

namespace UnitTest
{
    public class TodoServiceTest
    {
        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// Test to check getall working properly
        /// </summary>
        [Test]
        public void CanGetAllTodo()
        {
            // setup
            var options = new DbContextOptionsBuilder<TodoContext>()
               .UseInMemoryDatabase(databaseName: "TodoDb1")
               .Options;

            using (var context = new TodoContext(options))
            {
                context.Todos.Add(new Todo { Title = "Test Todo 1", Description = "Description Todo 1" });
                context.Todos.Add(new Todo { Title = "Test Todo 2", Description = "Description Todo 2" });
                context.Todos.Add(new Todo { Title = "Test Todo 3", Description = "Description Todo 3" });
                context.Todos.Add(new Todo { Title = "Test Todo 4", Description = "Description Todo 4" });
                context.Todos.Add(new Todo { Title = "Test Todo 5", Description = "Description Todo 5" });
                context.SaveChanges();
            }

            // operation
            var todoService = new TodoService(new TodoContext(options));
            var result = todoService.GetAll();

            // assert
            Assert.IsTrue(result.Any());
        }

        /// <summary>
        /// Can get by id
        /// </summary>
        [Test]
        public void CanGetByIdTodo()
        {
            // setup
            var options = new DbContextOptionsBuilder<TodoContext>()
               .UseInMemoryDatabase(databaseName: "TodoDb2")
               .Options;

            using (var context = new TodoContext(options))
            {
                context.Todos.Add(new Todo { Title = "Test Todo 1", Description = "Description Todo 1" });
                context.Todos.Add(new Todo { Title = "Test Todo 2", Description = "Description Todo 2" });
                context.Todos.Add(new Todo { Title = "Test Todo 3", Description = "Description Todo 3" });
                context.Todos.Add(new Todo { Title = "Test Todo 4", Description = "Description Todo 4" });
                context.Todos.Add(new Todo { Title = "Test Todo 5", Description = "Description Todo 5" });
                context.SaveChanges();
            }

            // operation
            var todoService = new TodoService(new TodoContext(options));
            var result = todoService.GetById(1);

            // assert
            Assert.NotNull(result);
            Assert.AreEqual("Test Todo 1", result.Title);
        }

        /// <summary>
        /// Create a todo
        /// </summary>
        [Test]
        public void CanCreateTodo()
        {
            // setup
            var options = new DbContextOptionsBuilder<TodoContext>()
               .UseInMemoryDatabase(databaseName: "TodoDb3")
               .Options;

            using (var context = new TodoContext(options))
            {
                context.Todos.Add(new Todo { Title = "Test Todo 1", Description = "Description Todo 1" });
                context.SaveChanges();
            }

            // operation
            var todoService = new TodoService(new TodoContext(options));
            var result = todoService.Insert(new Todo { Title = "From Insert", Description = "From Insert" });

            // assert
            Assert.AreEqual(2, result); // since Id is auto-increment, 2 is expected
        }

        /// <summary>
        /// Update a todo
        /// </summary>
        [Test]
        public void CanUpdateTodo()
        {
            // setup
            var options = new DbContextOptionsBuilder<TodoContext>()
               .UseInMemoryDatabase(databaseName: "TodoDb4")
               .Options;

            using (var context = new TodoContext(options))
            {
                context.Todos.Add(new Todo { Title = "Test Todo 1", Description = "Description Todo 1" });
                context.Todos.Add(new Todo { Title = "Test Todo 2", Description = "Description Todo 2" });
                context.Todos.Add(new Todo { Title = "Test Todo 3", Description = "Description Todo 3" });
                context.Todos.Add(new Todo { Title = "Test Todo 4", Description = "Description Todo 4" });
                context.Todos.Add(new Todo { Title = "Test Todo 5", Description = "Description Todo 5" });
                context.SaveChanges();
            }

            // operation
            var todoService = new TodoService(new TodoContext(options));
            var result = todoService.Update(1, new Todo { Title = "Test Todo 1 Updated", Description = "Description Todo 1" });

            // assert
            Assert.AreEqual("Test Todo 1 Updated", result.Title);
        }

        /// <summary>
        /// Delete a todo
        /// </summary>
        [Test]
        public void CanDeleteTodo()
        {
            // setup
            var options = new DbContextOptionsBuilder<TodoContext>()
               .UseInMemoryDatabase(databaseName: "TodoDb5")
               .Options;

            using (var context = new TodoContext(options))
            {
                context.Todos.Add(new Todo { Title = "Test Todo 1", Description = "Description Todo 1" });
                context.Todos.Add(new Todo { Title = "Test Todo 2", Description = "Description Todo 2" });
                context.Todos.Add(new Todo { Title = "Test Todo 3", Description = "Description Todo 3" });
                context.Todos.Add(new Todo { Title = "Test Todo 4", Description = "Description Todo 4" });
                context.Todos.Add(new Todo { Title = "Test Todo 5", Description = "Description Todo 5" });
                context.SaveChanges();
            }

            // operation
            var todoService = new TodoService(new TodoContext(options));
            var result = todoService.Delete(1);

            // assert
            Assert.AreEqual(1, result.Id);
        }

        /// <summary>
        /// Mark done a todo
        /// </summary>
        [Test]
        public void CanMarkDoneATodo()
        {
            // setup
            var options = new DbContextOptionsBuilder<TodoContext>()
               .UseInMemoryDatabase(databaseName: "TodoDb6")
               .Options;

            using (var context = new TodoContext(options))
            {
                context.Todos.Add(new Todo { Title = "Test Todo 1", Description = "Description Todo 1" });
                context.Todos.Add(new Todo { Title = "Test Todo 2", Description = "Description Todo 2" });
                context.Todos.Add(new Todo { Title = "Test Todo 3", Description = "Description Todo 3" });
                context.Todos.Add(new Todo { Title = "Test Todo 4", Description = "Description Todo 4" });
                context.Todos.Add(new Todo { Title = "Test Todo 5", Description = "Description Todo 5" });
                context.SaveChanges();
            }

            // operation
            var todoService = new TodoService(new TodoContext(options));
            var result = todoService.MarkDone(1);

            // assert
            Assert.AreEqual(1, result.Id);
            Assert.AreEqual(true, result.IsDone);
        }

        /// <summary>
        /// Set percent done for a todo
        /// </summary>
        [Test]
        public void CanSetPercentATodo()
        {
            // setup
            var options = new DbContextOptionsBuilder<TodoContext>()
               .UseInMemoryDatabase(databaseName: "TodoDb7")
               .Options;

            using (var context = new TodoContext(options))
            {
                context.Todos.Add(new Todo { Title = "Test Todo 1", Description = "Description Todo 1" });
                context.Todos.Add(new Todo { Title = "Test Todo 2", Description = "Description Todo 2" });
                context.Todos.Add(new Todo { Title = "Test Todo 3", Description = "Description Todo 3" });
                context.Todos.Add(new Todo { Title = "Test Todo 4", Description = "Description Todo 4" });
                context.Todos.Add(new Todo { Title = "Test Todo 5", Description = "Description Todo 5" });
                context.SaveChanges();
            }

            // operation
            var todoService = new TodoService(new TodoContext(options));
            var result = todoService.SetTodoPercentComplete(new SetTodoPercentCompleteDto
            {
                Id = 1,
                PercentComplete = 90
            });

            // assert
            Assert.AreEqual(1, result.Id);
            Assert.AreEqual(90, result.PercentComplete);

        }

        /// <summary>
        /// Get incoming todo
        /// </summary>
        [Test]
        public void CanGetIncomingTodo()
        {
            // setup
            var options = new DbContextOptionsBuilder<TodoContext>()
               .UseInMemoryDatabase(databaseName: "TodoDb8")
               .Options;

            using (var context = new TodoContext(options))
            {
                context.Todos.Add(new Todo { Title = "Test Todo 1", Description = "Description Todo 1", ExpiredAt = DateTime.Now });
                context.Todos.Add(new Todo { Title = "Test Todo 2", Description = "Description Todo 2", ExpiredAt = DateTime.Now });
                context.Todos.Add(new Todo { Title = "Test Todo 3", Description = "Description Todo 3", ExpiredAt = DateTime.Now.AddDays(1)});
                context.Todos.Add(new Todo { Title = "Test Todo 4", Description = "Description Todo 4", ExpiredAt = DateTime.Now.AddDays(7)});
                context.Todos.Add(new Todo { Title = "Test Todo 5", Description = "Description Todo 5", ExpiredAt = DateTime.Now.AddDays(7)});
                context.SaveChanges();
            }

            // operation
            var todoService = new TodoService(new TodoContext(options));
            var result = todoService.GetIncomingTodo(IncomingType.Today);

            // assert
            Assert.AreEqual(2, result.Count()); // incoming for today are 2

        }
    }
}