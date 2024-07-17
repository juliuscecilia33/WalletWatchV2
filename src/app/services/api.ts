import axios from "axios";

const api = axios.create({
  baseURL: "http://localhost:5259/walletwatchapi",
});

export const getTransactions = async () => {
  const response = await api.get("/transactions");
  return response.data;
};

export const addTransaction = async (transaction: any) => {
  await api.post("/add", transaction);
};

export const deleteTransaction = async (index: number) => {
  await api.delete(`/delete/${index}`);
};

export const getSummary = async () => {
  const response = await api.get("/summary");
  return response.data;
};
