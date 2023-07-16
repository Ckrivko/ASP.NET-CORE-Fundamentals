using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskBoardApp.Data.Models;

namespace TaskBoardApp.Data.Configurations
{
    internal class BoardEntityConfiguration : IEntityTypeConfiguration<Board>
    {
        public void Configure(EntityTypeBuilder<Board> builder)
        {
            ICollection<Board> boards = this.GenerateBoards();

            builder.HasData(boards);
        }

        private ICollection<Board> GenerateBoards()
        {
            ICollection<Board> boards = new HashSet<Board>();

            Board currBoard;
            currBoard = new Board()
            {
                Id = 1,
                Name = "Open"
            };
            boards.Add(currBoard);

            currBoard = new Board()
            {
                Id = 2,
                Name = "In Progress"
            };
            boards.Add(currBoard);

            currBoard = new Board()
            {
                Id = 3,
                Name = "Done"
            };
            boards.Add(currBoard);

            return boards;
        }
    }
}
