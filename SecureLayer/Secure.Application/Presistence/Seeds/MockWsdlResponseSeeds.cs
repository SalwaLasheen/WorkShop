using Secure.Presistence.Context;

namespace Secure.Application.Presistence
{
    public class MockWsdlResponseSeeds
    {

        public static void MockWsdlResponseSeedsAsync(SqlDbContext context)
        {
            if (context.ResponseWsdls.Any())
                return;
            try
            {

                var responseWsdl = new List<ResponseWsdl>();
                var options = new List<OptionsList>();
                options.AddRange(new List<OptionsList>
                {
                    new OptionsList
                    {
                        OptionId = 19,
                        OptionName="Change Package"
                    },
                     new OptionsList
                    {
                        OptionId = 7,
                        OptionName="Renew"
                    }

                });
             
                responseWsdl.AddRange(new List<ResponseWsdl>
                {
                    new ResponseWsdl
                    {
                        Dial = "01200000001",
                        ErrorCode = "er0000",
                        ErrorMessage = "Success",
                        Status = 0,
                        IsRnR=false,
                        RnRText="xxxx",
                        OptionsList =new List<OptionsList>
                    {
                     new OptionsList
                    {
                        OptionId=1,
                        OptionName="Subscribe"
                    }}
                        },
                     new ResponseWsdl
                    {
                        Dial = "01200000002",
                        ErrorCode = "er2056",
                        ErrorMessage = "Techincal Error",
                        Status = 1,
                        IsRnR=false,
                        RnRText="xxxx",

                },
                    new ResponseWsdl
                    {
                        Dial = "01200000003",
                        ErrorCode = "er0000",
                        ErrorMessage = "Success",
                        Status = 0,
                        IsRnR=false,
                        RnRText="xxxx",
                        OptionsList=options,
                        BucketId=5100,
                        BucketName="Go 100"
                    },
                    new ResponseWsdl
                    {
                        Dial = "01200000004",
                        ErrorCode = "er3000",
                        ErrorMessage = "Not eligible",
                        Status = 1,
                        IsRnR=false,
                        RnRText="xxxx",
                        OptionsList=options,
                        BucketId=5100,
                        BucketName="Go 100"
                    }
                     });
                using var transaction = new System.Transactions.TransactionScope();
                context.OptionsLists.AddRange(options);
                context.ResponseWsdls.AddRange(responseWsdl);
                context.SaveChanges();
                transaction.Complete();

            }
            catch (Exception)
            {

                throw;
            }

        }

    }
}

