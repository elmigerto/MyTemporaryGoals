using System;
using System.Collections.Generic;

namespace MyTemporaryGoals.DataManipulation
{
    public static class DataTransfer
    {
        public static List<TaskClass> task = new List<TaskClass>();

        public static bool saveProperty<T>(T property)
        {
            return true;
        }

        public static bool addTask(TaskClass taskToAdd)
        {
            task.Add(taskToAdd);
            return true;
        }
        public static bool storeTask()
        {
            
            return true;
            // here, the task should be saved in the properties
        }
    }
}
