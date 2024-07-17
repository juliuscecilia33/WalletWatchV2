import React, { useEffect, useState } from "react";
import { getTransactions, deleteTransaction } from "../services/api";

const TransactionList: React.FC = () => {
  const [transactions, setTransactions] = useState<any[]>([]);

  useEffect(() => {
    const fetchTransactions = async () => {
      const data = await getTransactions();
      setTransactions(data);
    };

    fetchTransactions();
  }, []);

  const handleDelete = async (index: number) => {
    await deleteTransaction(index);
    setTransactions(transactions.filter((_, i) => i !== index));
  };

  return (
    <div>
      <h2>Transactions</h2>
      <ul>
        {transactions.map((transaction, index) => (
          <li key={index}>
            {transaction.date} - {transaction.description} -{" "}
            {transaction.amount} - {transaction.isIncome ? "Income" : "Expense"}
            <button onClick={() => handleDelete(index)}>Delete</button>
          </li>
        ))}
      </ul>
    </div>
  );
};

export default TransactionList;
