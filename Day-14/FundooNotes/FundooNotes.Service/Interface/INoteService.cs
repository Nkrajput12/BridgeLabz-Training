using FundooNotes.Models;
using FundooNotes.Models.DTOs;

namespace FundooNotes.Service.Interface
{
    public interface INoteService
    {
        Task<NotesEntity> CreateNoteAsync(CreateNoteDto noteDto, int userId);
        Task<IEnumerable<NotesEntity>> GetAllNotesAsync(int userId);
        Task<bool> DeleteNoteAsync(long noteId, int userId);
    }
}
