﻿using System;


namespace R5T.F0121.Extensions
{
    public static class CharacterExtensions
    {
        public static KindMarker ToKindMarker(this char value)
        {
            return Instances.CharacterOperator.ToKindMarker(value);
        }
    }
}
