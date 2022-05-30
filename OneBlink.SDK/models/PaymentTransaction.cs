using System;

namespace OneBlink.SDK.Model
{
    public class PaymentTransaction
    {
        #region CP Pay
        public string transactionId
        {
            get; set;
        }
        public string transactionToken
        {
            get; set;
        }
        public string merchantCode
        {
            get; set;
        }
        public string orderNumber
        {
            get; set;
        }
        public int chargeTypeId
        {
            get; set;
        }
        public int creditCardTypeId
        {
            get; set;
        }
        public int paymentTypeId
        {
            get; set;
        }
        public double amount
        {
            get; set;
        }
        public string lastFour
        {
            get; set;
        }
        public int expMonth
        {
            get; set;
        }
        public int expYear
        {
            get; set;
        }
        public int resultCode
        {
            get; set;
        }
        public int errorCode
        {
            get; set;
        }
        public string errorMessage
        {
            get; set;
        }
        public string savedPaymentMethodToken
        {
            get; set;
        }
        public string customerReceipt
        {
            get; set;
        }
        public string merchantReceipt
        {
            get; set;
        }
        public int initialChargeStatusId
        {
            get; set;
        }
        public int currentChargeStatusId
        {
            get; set;
        }
        public DateTime? currentChargeStatusDtm
        {
            get; set;
        }
        public DateTime? createdAt
        {
            get; set;
        }
        public DateTime? updatedAt
        {
            get; set;
        }
        public DateTime? deletedAt
        {
            get; set;
        }
        public string customerSignature
        {
            get; set;
        }
        public string customerSignatureFormat
        {
            get; set;
        }
        public bool isSuccessSavedPaymentMethod
        {
            get; set;
        }
        #endregion

        #region BPoint
        public string Action
        {
            get; set;
        }
        public double Amount
        {
            get; set;
        }
        public double AmountOriginal
        {
            get; set;
        }
        public double AmountSurcharge
        {
            get; set;
        }
        public string AuthoriseId
        {
            get; set;
        }
        public BPointBankAccountDetails BankAccountDetails
        {
            get; set;
        }
        public string BankResponseCode
        {
            get; set;
        }
        public string BillerCode
        {
            get; set;
        }
        public BPointCardDetails CardDetails
        {
            get; set;
        }
        public string CardType
        {
            get; set;
        }
        public string Crn1
        {
            get; set;
        }
        public string Crn2
        {
            get; set;
        }
        public string Crn3
        {
            get; set;
        }
        public string Currency
        {
            get; set;
        }
        public BPointCVNResult CVNResult
        {
            get; set;
        }
        public string DVToken
        {
            get; set;
        }
        public string EmailAddress
        {
            get; set;
        }
        public BPointFraudScreeningResponse FraudScreeningResponse
        {
            get; set;
        }
        public bool IsThreeDS
        {
            get; set;
        }
        public bool IsCVNPresent
        {
            get; set;
        }
        public bool IsTestTxn
        {
            get; set;
        }
        public string MerchantNumber
        {
            get; set;
        }
        public string MerchantReference
        {
            get; set;
        }
        public string OriginalTxnNumber
        {
            get; set;
        }
        public string ProcessedDateTime
        {
            get; set;
        }
        public string ReceiptNumber
        {
            get; set;
        }
        public string ReceiptCode
        {
            get; set;
        }
        public string ReceiptText
        {
            get; set;
        }
        public string RRN
        {
            get; set;
        }
        public string SettlementDate
        {
            get; set;
        }
        public string Source
        {
            get; set;
        }
        public bool StoreCard
        {
            get; set;
        }
        public BPointThreeDSResponse ThreeDSResponse
        {
            get; set;
        }
        public string TxnNumber
        {
            get; set;
        }
        public string Type
        {
            get; set;
        }
        public BPointStatementDescriptor StatementDescriptor
        {
            get; set;
        }
        #endregion
        #region Westpac

        public string sourceCode
        {
            get; set;
        }
        public string receiptNumber
        {
            get; set;
        }
        public string communityCode
        {
            get; set;
        }
        public string supplierBusinessCode
        {
            get; set;
        }
        public string paymentReference
        {
            get; set;
        }
        public string customerReferenceNumber
        {
            get; set;
        }
        public string paymentAmount
        {
            get; set;
        }
        public string surchargeAmount
        {
            get; set;
        }
        public string cardScheme
        {
            get; set;
        }
        public string settlementDate
        {
            get; set;
        }
        public string createdDateTime
        {
            get; set;
        }
        public string responseCode
        {
            get; set;
        }
        public string responseDescription
        {
            get; set;
        }
        public string successFlag
        {
            get; set;
        }

        #endregion
    }
}