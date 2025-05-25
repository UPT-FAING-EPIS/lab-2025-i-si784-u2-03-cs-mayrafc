using System;

namespace Bank.Domain
{
    /// <summary>
    /// Representa una cuenta bancaria que permite realizar operaciones de débito y crédito.
    /// </summary>
    public class BankAccount
    {
        /// <summary>
        /// Mensaje de error cuando el monto a debitar excede el saldo disponible.
        /// </summary>
        public const string DebitAmountExceedsBalanceMessage = "Debit amount exceeds balance";

        /// <summary>
        /// Mensaje de error cuando el monto a debitar es menor que cero.
        /// </summary>
        public const string DebitAmountLessThanZeroMessage = "Debit amount is less than zero";

        private readonly string m_customerName;
        private double m_balance;

        /// <summary>
        /// Constructor privado para evitar la creación sin parámetros.
        /// </summary>
        private BankAccount() { }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="BankAccount"/>.
        /// </summary>
        /// <param name="customerName">Nombre del cliente propietario de la cuenta.</param>
        /// <param name="balance">Saldo inicial de la cuenta.</param>
        public BankAccount(string customerName, double balance)
        {
            m_customerName = customerName;
            m_balance = balance;
        }

        /// <summary>
        /// Obtiene el nombre del cliente.
        /// </summary>
        public string CustomerName { get { return m_customerName; } }

        /// <summary>
        /// Obtiene el saldo actual de la cuenta.
        /// </summary>
        public double Balance { get { return m_balance; } }

        /// <summary>
        /// Realiza un débito (retiro) de la cuenta.
        /// </summary>
        /// <param name="amount">Monto a debitar.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Se lanza cuando el monto a debitar es mayor que el saldo o menor que cero.
        /// </exception>
        public void Debit(double amount)
        {
            if (amount > m_balance)
                throw new ArgumentOutOfRangeException("amount", amount, DebitAmountExceedsBalanceMessage);
            if (amount < 0)
                throw new ArgumentOutOfRangeException("amount", amount, DebitAmountLessThanZeroMessage);
            m_balance -= amount;
        }

        /// <summary>
        /// Realiza un crédito (depósito) en la cuenta.
        /// </summary>
        /// <param name="amount">Monto a acreditar.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Se lanza cuando el monto es menor que cero.
        /// </exception>
        public void Credit(double amount)
        {
            if (amount < 0)
                throw new ArgumentOutOfRangeException("amount");
            m_balance += amount;
        }
    }
}
