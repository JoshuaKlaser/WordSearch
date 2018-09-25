using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Random.Classes
{
    public class SubmissionResponse
    {
        public WordData Data { get; private set; }
        public bool Success { get; private set; }

        public SubmissionResponse(bool success, WordData data)
        {
            Data = data;
            Success = success;
        }
    }
}
