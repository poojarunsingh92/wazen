using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenTransactions.Application.Features.CoverNotes.GetCoverNote;
using WazenTransactions.Application.Responses;

namespace WazenTransactions.Application.Features.CoverNote.Queries.GetCoverNote
{
    public class GetCoverNoteDetailQuery : IRequest<Response<CoverNoteDetailVm>>
    {
    }
}
