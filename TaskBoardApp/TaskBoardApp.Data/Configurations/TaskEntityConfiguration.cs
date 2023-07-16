using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Task = TaskBoardApp.Data.Models.Task;

namespace TaskBoardApp.Data.Configurations
{
    internal class TaskEntityConfiguration : IEntityTypeConfiguration<Task>
    {
        public void Configure(EntityTypeBuilder<Task> builder)
        {
            builder               
               .HasOne(t => t.Board)
               .WithMany(b => b.Tasks)
               .HasForeignKey(b => b.BoardId)
               .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(this.GenerateTasks());
        }

        private ICollection<Task> GenerateTasks()
        {
            ICollection<Task> tasks = new HashSet<Task>()
            {
                new Task
                {
                Title="Improve CSS Style",
                Description="Implement better styling for better pagfes",
                CreatedOn=DateTime.Now.AddDays(-200),
                OwnerId="167c8d87-45bf-4c19-ba39-88d1b052f693",
                BoardId=1
                },
                new Task()
                {
                Title="Android client App",
                Description="Create Android client- app for RESTFUL  TaskBoard",
                CreatedOn=DateTime.Now.AddDays(-5),
                OwnerId="287004ef-d23f-4331-85ca-1f91d7abf8cf",
                BoardId=1
                },
                new Task
                {
                Title="Desctop client App",
                Description="Create really cool dectop application",
                CreatedOn=DateTime.Now.AddDays(-1),
                OwnerId="167c8d87-45bf-4c19-ba39-88d1b052f693",
                BoardId=2,
                },
                new Task()
                {
                Title="Create tasks",
                Description="Implement create- task functionality for any kind of app",
                CreatedOn=DateTime.Now.AddDays(-1),
                OwnerId="167c8d87-45bf-4c19-ba39-88d1b052f693",
                BoardId=3
                }            
            };

            return tasks;
        }
    }
}
