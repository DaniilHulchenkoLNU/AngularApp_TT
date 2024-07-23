import { СryptoRate } from "./СryptoRate";

export interface User {
  id: string; // ObjectId
  email: string;
  password: string;
  userHistoryList: СryptoRate;
}
