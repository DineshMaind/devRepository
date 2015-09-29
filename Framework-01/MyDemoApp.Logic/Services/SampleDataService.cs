using MyDemoApp.Logic.Models;
using MyDemoApp.Core;
using MyDemoApp.Entities;

namespace MyDemoApp.Logic.Services
{
    public class SampleDataService : ModelService<sample_data, SampleDataModel, long>
    {
        public SampleDataService(ModelRepository db)
            : base(new ModelServiceBase<sample_data, SampleDataModel, long>(db, x =>
                  new SampleDataModel
                  {
                      Id = x.id,
                      Col01 = x.col01,
                      Col02 = x.col02,
                      Col03 = x.col03,
                      Col04 = x.col04,
                      Col05 = x.col05,
                      Col06 = x.col06,
                      Col07 = x.col07,
                      Col08 = x.col08,
                      Col09 = x.col09,
                      Col10 = x.col10,
                      Col11 = x.col11,
                      Col12 = x.col12,
                      Col13 = x.col13,
                      Col14 = x.col14,
                      Col15 = x.col15,
                      Col16 = x.col16,
                      Col17 = x.col17,
                      Col18 = x.col18,
                      Col19 = x.col19,
                      Col20 = x.col20,
                      Col21 = x.col21,
                      Col22 = x.col22,
                      Col23 = x.col23,
                      Col24 = x.col24,
                      Col25 = x.col25,
                      Col26 = x.col26,
                      Col27 = x.col27,
                      Col28 = x.col28,
                      Col29 = x.col29,
                      Col30 = x.col30,
                  }, x =>
                  new sample_data
                  {
                      id = x.Id,
                      col01 = x.Col01,
                      col02 = x.Col02,
                      col03 = x.Col03,
                      col04 = x.Col04,
                      col05 = x.Col05,
                      col06 = x.Col06,
                      col07 = x.Col07,
                      col08 = x.Col08,
                      col09 = x.Col09,
                      col10 = x.Col10,
                      col11 = x.Col11,
                      col12 = x.Col12,
                      col13 = x.Col13,
                      col14 = x.Col14,
                      col15 = x.Col15,
                      col16 = x.Col16,
                      col17 = x.Col17,
                      col18 = x.Col18,
                      col19 = x.Col19,
                      col20 = x.Col20,
                      col21 = x.Col21,
                      col22 = x.Col22,
                      col23 = x.Col23,
                      col24 = x.Col24,
                      col25 = x.Col25,
                      col26 = x.Col26,
                      col27 = x.Col27,
                      col28 = x.Col28,
                      col29 = x.Col29,
                      col30 = x.Col30,
                  }, x=> x.id))
        {
        }
    }
}