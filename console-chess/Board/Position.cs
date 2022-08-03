namespace board
{
    internal class Position
    {
        public int Line { get; set; }
        public int Column { get; set; }

        public Position(int line, int column)
        {
            Line = line;
            Column = column;
        }

        public void setValues(int line, int column) //Method to set the value of position
        {
            Line = line;
            Column = column;
        }

        public override string ToString()
        {
            return Line 
                +","
                + Column;
        }
    }
}
