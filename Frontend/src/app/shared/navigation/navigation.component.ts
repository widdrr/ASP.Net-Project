import { Component } from '@angular/core';
import { UserService } from '../../core/services/user.service';

@Component({
  selector: 'app-navigation',
  templateUrl: './navigation.component.html',
  styleUrls: ['./navigation.component.css']
})
export class NavigationComponent {

  constructor(private readonly userService: UserService) { }

  isLogged(): boolean {
    return this.userService.isLoggedIn();
  }
  logout(): void {
    this.userService.logout();
    window.location.reload();
  }
}
