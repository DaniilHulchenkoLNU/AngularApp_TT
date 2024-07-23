import { Component, Inject, Renderer2 } from '@angular/core';
import { DOCUMENT } from '@angular/common';
import { AuthService } from '../../../../../service/Auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  
})
export class LoginComponent {

  constructor(private as: AuthService, private renderer: Renderer2, @Inject(DOCUMENT) private document: Document) { }

  login(email: string, password: string) {
    this.as.login(email, password)
      .subscribe(res => {
        this.removeModalBackdrop();
        //this.userServise.setUser();
      }, error => {
        alert('Wrong login or password.')
      })
    
  }

  logout() {
    this.as.logout()
    //this.userServise.clearUser();
  }

  private removeModalBackdrop() {
    const element = this.document.querySelector('.modal-backdrop.fade.show');
    if (element) {
      this.renderer.removeChild(this.document.body, element);

    }
  }
}
