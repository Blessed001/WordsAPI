using AutoMapper;
using WordsAPI.DTOs;
using WordsAPI.Models;

namespace WordsAPI.Profiles
{
    public class WordProfile:Profile
    {
        public WordProfile()
        {
            CreateMap<Word, ReadWordsDTO>();
            CreateMap<CreateWordDTO, Word>();
            CreateMap<UpDateWordDTO, Word>();
        }
    }
}