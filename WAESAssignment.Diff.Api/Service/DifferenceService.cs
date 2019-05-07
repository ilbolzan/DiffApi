using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WAESAssignment.Diff.Api.DTO;
using WAESAssignment.Diff.Api.Interfaces.Repository;
using WAESAssignment.Diff.Api.Interfaces.Service;

namespace WAESAssignment.Diff.Api.Service
{
    public class DifferenceService : IDifferenceService
    {
        protected readonly IDifferenceLeftRepository _differenceLeftRepository;
        protected readonly IDifferenceRightRepository _differenceRightRepository;

        public DifferenceService(
            IDifferenceLeftRepository differenceLeftRepository,
            IDifferenceRightRepository differenceRightRepository)
        {
            _differenceLeftRepository = differenceLeftRepository;
            _differenceRightRepository = differenceRightRepository;
        }
        public ResultComparisson Compare(int id)
        {
            var diffLeftTask = _differenceLeftRepository.GetById(id);
            var diffRightTask = _differenceRightRepository.GetById(id);

            Task.WaitAll(diffLeftTask, diffRightTask);

            var valueLeft = diffLeftTask.Result;
            var valueRight = diffRightTask.Result;

            if(valueLeft is null && valueRight is null)
            {
                throw new NonExistentComparissonException();
            }

            if (valueLeft.Equals(valueRight))
            {
                //Both are equal: same size and same values
                return new ResultComparisson("EQUAL");
            }
            else if(valueLeft.Base64String.Length != valueRight.Base64String.Length)
            {
                //Both have different Sizes
                return new ResultComparisson("DIFFERENT_SIZES");
            }
            else
            {
                //Both have same size, but different content
                var offsets = new List<OffsetInsight>();
                var left = valueLeft.Base64String;
                var right = valueRight.Base64String;

                int index = 0;
                int lenght = 0;
                for (int i = 0; i < left.Length-1; i++)
                {
                    
                    if(left[i] != right[i])
                    {
                        if(index == 0)
                        {
                            index = i;
                        }
                        lenght++;
                    }
                    else
                    {
                        if (index != 0)
                        {
                            offsets.Add(new OffsetInsight(index, lenght));
                            index = 0;
                            lenght = 0;
                        }
                    }
                }
                return new ResultComparisson("SAME_SIZE_BUT_DIFFERENT_DATA", offsets);
            }
        }
    }
}
