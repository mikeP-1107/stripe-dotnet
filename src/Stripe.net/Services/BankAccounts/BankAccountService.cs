﻿namespace Stripe
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Stripe.Infrastructure;

    public class BankAccountService : StripeService
    {
        public BankAccountService()
            : base(null)
        {
        }

        public BankAccountService(string apiKey)
            : base(apiKey)
        {
        }

        public bool ExpandCustomer { get; set; }

        public virtual CustomerBankAccount Create(string customerId, BankAccountCreateOptions createOptions, StripeRequestOptions requestOptions = null)
        {
            return Mapper<CustomerBankAccount>.MapFromJson(
                Requestor.PostString(
                    this.ApplyAllParameters(createOptions, $"{Urls.BaseUrl}/customers/{customerId}/bank_accounts"),
                    this.SetupRequestOptions(requestOptions)));
        }

        public virtual CustomerBankAccount Get(string customerId, string bankAccountId, StripeRequestOptions requestOptions = null)
        {
            return Mapper<CustomerBankAccount>.MapFromJson(
                Requestor.GetString(
                    this.ApplyAllParameters(null, $"{Urls.BaseUrl}/customers/{customerId}/sources/{bankAccountId}"),
                    this.SetupRequestOptions(requestOptions)));
        }

        public virtual CustomerBankAccount Update(string customerId, string bankAccountId, BankAccountUpdateOptions updateOptions, StripeRequestOptions requestOptions = null)
        {
            return Mapper<CustomerBankAccount>.MapFromJson(
                Requestor.PostString(
                    this.ApplyAllParameters(updateOptions, $"{Urls.BaseUrl}/customers/{customerId}/sources/{bankAccountId}"),
                    this.SetupRequestOptions(requestOptions)));
        }

        public virtual StripeDeleted Delete(string customerId, string bankAccountId, StripeRequestOptions requestOptions = null)
        {
            return Mapper<StripeDeleted>.MapFromJson(
                Requestor.Delete(
                    this.ApplyAllParameters(null, $"{Urls.BaseUrl}/customers/{customerId}/sources/{bankAccountId}"),
                    this.SetupRequestOptions(requestOptions)));
        }

        public virtual StripeList<CustomerBankAccount> List(string customerId, BankAccountListOptions listOptions = null, StripeRequestOptions requestOptions = null)
        {
            return Mapper<StripeList<CustomerBankAccount>>.MapFromJson(
                Requestor.GetString(
                    this.ApplyAllParameters(listOptions, $"{Urls.BaseUrl}/customers/{customerId}/bank_accounts", true),
                    this.SetupRequestOptions(requestOptions)));
        }

        public virtual CustomerBankAccount Verify(string customerId, string bankAccountId, BankAccountVerifyOptions verifyoptions, StripeRequestOptions requestOptions = null)
        {
            return Mapper<CustomerBankAccount>.MapFromJson(
                Requestor.PostString(
                    this.ApplyAllParameters(verifyoptions, $"{Urls.BaseUrl}/customers/{customerId}/sources/{bankAccountId}/verify"),
                    this.SetupRequestOptions(requestOptions)));
        }

        public virtual async Task<CustomerBankAccount> CreateAsync(string customerId, BankAccountCreateOptions createOptions, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Mapper<CustomerBankAccount>.MapFromJson(
                await Requestor.PostStringAsync(
                    this.ApplyAllParameters(createOptions, $"{Urls.BaseUrl}/customers/{customerId}/bank_accounts"),
                    this.SetupRequestOptions(requestOptions),
                    cancellationToken).ConfigureAwait(false));
        }

        public virtual async Task<CustomerBankAccount> GetAsync(string customerId, string bankAccountId, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Mapper<CustomerBankAccount>.MapFromJson(
                await Requestor.GetStringAsync(
                    this.ApplyAllParameters(null, $"{Urls.BaseUrl}/customers/{customerId}/sources/{bankAccountId}"),
                    this.SetupRequestOptions(requestOptions),
                    cancellationToken).ConfigureAwait(false));
        }

        public virtual async Task<CustomerBankAccount> UpdateAsync(string customerId, string bankAccountId, BankAccountUpdateOptions updateOptions, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Mapper<CustomerBankAccount>.MapFromJson(
                await Requestor.PostStringAsync(
                    this.ApplyAllParameters(updateOptions, $"{Urls.BaseUrl}/customers/{customerId}/sources/{bankAccountId}"),
                    this.SetupRequestOptions(requestOptions),
                    cancellationToken).ConfigureAwait(false));
        }

        public virtual async Task<StripeDeleted> DeleteAsync(string customerId, string bankAccountId, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Mapper<StripeDeleted>.MapFromJson(
                await Requestor.DeleteAsync(
                    this.ApplyAllParameters(null, $"{Urls.BaseUrl}/customers/{customerId}/sources/{bankAccountId}"),
                    this.SetupRequestOptions(requestOptions),
                    cancellationToken).ConfigureAwait(false));
        }

        public virtual async Task<StripeList<CustomerBankAccount>> ListAsync(string customerId, BankAccountListOptions listOptions = null, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Mapper<StripeList<CustomerBankAccount>>.MapFromJson(
                await Requestor.GetStringAsync(
                    this.ApplyAllParameters(listOptions, $"{Urls.BaseUrl}/customers/{customerId}/bank_accounts", true),
                    this.SetupRequestOptions(requestOptions),
                    cancellationToken).ConfigureAwait(false));
        }

        public virtual async Task<CustomerBankAccount> VerifyAsync(string customerId, string bankAccountId, BankAccountVerifyOptions verifyoptions, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Mapper<CustomerBankAccount>.MapFromJson(
                await Requestor.PostStringAsync(
                    this.ApplyAllParameters(verifyoptions, $"{Urls.BaseUrl}/customers/{customerId}/sources/{bankAccountId}/verify"),
                    this.SetupRequestOptions(requestOptions),
                    cancellationToken).ConfigureAwait(false));
        }
    }
}