using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WordsAPI.Data;
using WordsAPI.DTOs;
using WordsAPI.Models;

namespace WordsAPI.Controllers
{
    [ApiController]
    [Route("api/words")]
    public class WordsController:ControllerBase
    {
        private readonly IWordRepo _repo;
        private readonly IMapper _mapper;

        public WordsController(IWordRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult <IEnumerable<ReadWordsDTO>> GetAll()
        {
            var words = _repo.GetAll();

            if(words == null)
            {
                return NoContent();
            }
            return Ok(_mapper.Map<IEnumerable<ReadWordsDTO>>(words));
        }

        [HttpGet("{Id}")]
        public ActionResult <ReadWordsDTO> GetWordById(int Id)
        {
          var word = _repo.GetWordById(Id);

          if(word == null)
          {
              return NotFound();
          }
          return Ok(_mapper.Map<ReadWordsDTO>(word));
        }

        [HttpPost]
        public ActionResult <ReadWordsDTO> CreateDTO(CreateWordDTO createWord)
        {
            var wordModel = _mapper.Map<Word>(createWord);

            _repo.CreateWord(wordModel);
            _repo.SaveChanges();

            var readWord = _mapper.Map<ReadWordsDTO>(wordModel);

            return Ok(readWord);
        }

        [HttpPut("{Id}")]
        public ActionResult <ReadWordsDTO> UpDateWord(int Id, UpDateWordDTO upDateWordDTO)
        {
            var wordToUpDate = _repo.GetWordById(Id);

            _mapper.Map<UpDateWordDTO, Word>(upDateWordDTO, wordToUpDate);

            _repo.UpDateWord(wordToUpDate);
            _repo.SaveChanges();

            return Ok(_mapper.Map<ReadWordsDTO>(wordToUpDate));
        }

        [HttpDelete("{Id}")]
        public ActionResult DeleteWord(int Id)
        {
            var wordToDelete = _repo.GetWordById(Id);

            if(wordToDelete == null)
            {
                return NotFound();
            }

            _repo.DeleteWord(wordToDelete);
            _repo.SaveChanges();

            return NoContent();
        }
    }
}