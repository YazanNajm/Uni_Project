using System.IO;
namespace Mazes
{
	public static class DiagonalMazeTask
	{
        
		public static void MoveOut(Robot robot, int width, int height)
		{
            Maze maze;
            maze = new Maze(File.ReadAllLines(Path.Combine("mazes", "diagonal3" + ".txt")));

            for (var i = 0; !robot.Finished; i++)
            {
                if (maze.IsWall(new System.Drawing.Point(robot.X + 1, robot.Y)))
                    robot.MoveTo(Direction.Down);
                else
                    robot.MoveTo(Direction.Right);
                if (robot.Finished)
                    break;
            }
        }
	}
}