namespace CleanCode.MagicNumbers
{
    class MagicNumbers
    {
        public void ApproveDocument(DocumentStatus status)
        {
            if (status == DocumentStatus.Draft)
            {
                // ...
            }
            else if (status == DocumentStatus.Lodged)
            {
                // ...
            }
        }

        public void RejectDocument(DocumentStatus status)
        {
            switch (status)
            {
                case DocumentStatus.Draft:
                    //...
                    break;
                case DocumentStatus.Lodged:
                    //....
                    break;
            }
        }
    }
}
