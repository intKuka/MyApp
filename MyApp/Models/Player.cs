﻿namespace MyApp.Models
{
    public class Player : Base
    {
        public bool InGame { get; set; }
        public char Side { get; set; }

        public Player()
        {
            Id = Guid.NewGuid();
            InGame = false;
        }
    }
}
