import { LibraryEntry } from "./library-entry";

export interface Library {
  id: string,
  games: Array<LibraryEntry>
}
