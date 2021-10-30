using System;
using System.Collections.Generic;
namespace ClassLibrary
{
    public interface IHandlerRespuestas
    {
        IHandlerRespuestas SetNext(IHandlerRespuestas handler);

        object Handle(object request);
    }
}