import React, { useState } from "react";
import { addTransaction, getSummary } from "./services/api";
import TransactionList from "./components/transaction";

const Home: React.FC = () => {
  const [date, setDate] = useState<string>("");
  const [description, setDescription] = useState<string>("");
  const [amount, setAmount] = useState<string>("");
  const [isIncome, setIsIncome] = useState<boolean>(true);
  const [summary, setSummary] = useState<{
    totalIncome: number;
    totalExpenses: number;
    netBalance: number;
  }>({ totalIncome: 0, totalExpenses: 0, netBalance: 0 });

  const handleAddTransaction = async () => {
    const transaction = {
      date,
      description,
      amount: parseFloat(amount),
      isIncome,
    };
    await addTransaction(transaction);
    const summaryData = await getSummary();
    setSummary(summaryData);
  };

  return (
    <div>
      <h1>Budget Tracker</h1>
      <div>
        <input
          type="date"
          value={date}
          onChange={(e) => setDate(e.target.value)}
        />
        <input
          type="text"
          placeholder="Description"
          value={description}
          onChange={(e) => setDescription(e.target.value)}
        />
        <input
          type="number"
          placeholder="Amount"
          value={amount}
          onChange={(e) => setAmount(e.target.value)}
        />
        <select
          value={isIncome.toString()}
          onChange={(e) => setIsIncome(e.target.value === "true")}
        >
          <option value="true">Income</option>
          <option value="false">Expense</option>
        </select>
        <button onClick={handleAddTransaction}>Add Transaction</button>
      </div>
      <TransactionList />
      <div>
        <h2>Summary</h2>
        <p>Total Income: {summary.totalIncome}</p>
        <p>Total Expenses: {summary.totalExpenses}</p>
        <p>Net Balance: {summary.netBalance}</p>
      </div>
    </div>
  );
};

export default Home;
