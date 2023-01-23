import { Inject, Injectable } from '@angular/core';
import { map } from 'rxjs';
import { Library } from '../../data/library';
import { LibraryEntry } from '../../data/library-entry';
import { ApiService } from './api.service';

@Injectable({
  providedIn: 'root'
})
export class LibraryService {
  private readonly route = 'library'
  private ownedGames?: Set<string>;

  constructor(private readonly apiService: ApiService) {
    this.refreshCache();
  }

  refreshCache(): void {

    const userId: string = localStorage.getItem('userId')!
    this.apiService.get(`${this.route}/${userId}`)
      .subscribe((data: Library) => this.ownedGames = new Set(
          data.games.map((game: LibraryEntry) => game.gameId)));
  }
  ownsGame(gameId: string): boolean {

    //here as a last failase in case ownedGames still haven't loaded
    if (this.ownedGames == null) {
      setTimeout(()=>300);
    }
    //to do: implement a more reliable way to check if user doesn't have a library
    if (this.ownedGames == null)
      return false;

    return this.ownedGames!.has(gameId);
  }
}
