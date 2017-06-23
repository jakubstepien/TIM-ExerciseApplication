using ApiClients.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClients
{
    public class ExcerciseClient : AuthorizedDataClient
    {
        public ExcerciseClient(string token) : base(token)
        {
            throw new NotImplementedException();
        }

        public Response<IEnumerable<ExerciseDTO>> GetExercises(Guid userId)
        {
            throw new NotImplementedException();

        }

        public Response<ExerciseDTO> GetExercise(Guid id)
        {
            throw new NotImplementedException();
        }

        public Response UpdateExercise(Guid id, ExerciseDTO exercise)
        {
            throw new NotImplementedException();
        }

        public Response AddExercise(Guid userId, ExerciseDTO exercise)
        {
            throw new NotImplementedException();
        }

        public Response DeleteExerciseFromUser(Guid id, Guid userId)
        {
            throw new NotImplementedException();
        }

        public Response FavouriteExercise(Guid id, Guid userId)
        {
            throw new NotImplementedException();

        }
    }
}
