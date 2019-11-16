﻿using System;

namespace TestLibrary.BusinessObject.Abstract
{
    public interface ITest
    {
        int TestId { get; }
        int TestParametersId { get; }
        int UserId { get; }
        int EndpointId { get; }
        DateTime DatabaseTestTime { get; }
        DateTime ApplicationTestTime { get; }
        DateTime ApiTestTime { get; }
    }
}