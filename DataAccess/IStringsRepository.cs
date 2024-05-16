﻿using System.Collections.Generic;

namespace Cookie_Cookbook.DataAccess
{
    public interface IStringsRepository
    {
        List<string> Read(string filePath);
        void Write(string filePath, List<string> strings);
    }
}
