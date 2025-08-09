import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';
import { Logo } from "../logo/logo";

@Component({
  selector: 'app-nav-bar',
  imports: [RouterLink, Logo],
  templateUrl: './nav-bar.html',
  styleUrl: './nav-bar.css'
})
export class NavBar {

}
