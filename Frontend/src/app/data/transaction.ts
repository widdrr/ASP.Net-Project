import { GamePurchase } from "./game-purchase";

export interface Transaction {
  userId: string,
  date: Date,
  type: string,
  sum: number,
  //for detailed responses
  games : Array<GamePurchase>
}
