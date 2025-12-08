import { Component } from '@angular/core';
import { NavBarComponent } from "../../Components/nav-bar-component/nav-bar-component";
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-admin-layout',
  imports: [NavBarComponent, RouterOutlet],
  templateUrl: './admin-layout.html',
  styleUrl: './admin-layout.css'
})
export class AdminLayout {

}
