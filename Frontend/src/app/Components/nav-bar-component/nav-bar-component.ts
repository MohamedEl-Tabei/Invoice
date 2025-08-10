import { Component } from '@angular/core';
import { LogoComponent } from "../logo-component/logo-component";
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-nav-bar-component',
  imports: [LogoComponent,RouterLink],
  templateUrl: './nav-bar-component.html',
  styleUrl: './nav-bar-component.css'
})
export class NavBarComponent {

}
