using FundooNotes.Models;
using FundooNotes.Models.DTOs;
using FundooNotes.Repository.Interface;
using FundooNotes.Service.Interface;

namespace FundooNotes.Service.Services
{
    public class NoteService : INoteService
    {
        private readonly INoteRepository _noteRepository;

        public NoteService(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public async Task<NotesEntity> CreateNoteAsync(CreateNoteDto noteDto, int userId)
        {
            var note = new NotesEntity
            {
                Title = noteDto.Title,
                Description = noteDto.Description,
                Reminder = noteDto.Reminder,
                Backgroundcolor = noteDto.Backgroundcolor,
                Image = noteDto.Image,
                Pin = noteDto.Pin,
                Archive = noteDto.Archive,
                Trash = false,
                UserId = userId
            };

            return await _noteRepository.CreateNoteAsync(note);
        }

        public async Task<IEnumerable<NotesEntity>> GetAllNotesAsync(int userId)
        {
            return await _noteRepository.GetAllNotesByUserIdAsync(userId);
        }

        public async Task<bool> DeleteNoteAsync(long noteId, int userId)
        {
            return await _noteRepository.DeleteNoteAsync(noteId, userId);
        }
    }
}
