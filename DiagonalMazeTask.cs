namespace Mazes
{
	public static class DiagonalMazeTask
	{
		public static void MoveOut(Robot robot, int width, int height)
		{
            if (width > height)
            {
                for (var i = 0; !robot.Finished; i++)
                {
                    if ()
                         robot.MoveTo(Direction.Right);
                    else
                        robot.MoveTo(Direction.Down);
                    if (robot.Finished)
                        break;
                } 
            }
            if (height > width)
            {
                for (var i = 0; !robot.Finished; i++)
                {
                    if ()
                        robot.MoveTo(Direction.Down);
                    else
                        robot.MoveTo(Direction.Right);
                    if (robot.Finished)
                        break;
                }
            }
        }
	}
}
