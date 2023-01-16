import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UserService } from '../../../core/services/user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  public loginForm = this.formBuilder.group({
    username: ['', Validators.required],
    password: ['', Validators.required]
  });

  constructor(private readonly formBuilder: FormBuilder,
              private readonly router: Router,
              private readonly authService: UserService) { }

  login() {
    this.authService.login(this.loginForm.value).subscribe(data => {
      console.log(data);
      this.router.navigate(['/browse']);
    })
  }
}
