﻿namespace SistemaGestaoQualidade.WebApi.Shared
{
    public class BaseResult<T>
    {
        public bool IsValid { get; set; }
        public string Message { get; set; }
        public T DataEntity { get; set; }
    }
}