import { Component } from '@angular/core';
import { InputDirective } from "../../Directives/input-directive";
import { Router } from '@angular/router';

@Component({
  selector: 'app-home-page',
  imports: [InputDirective,],
  templateUrl: './home-page.html',
  styleUrl: './home-page.css'
})
export class HomePage {
  constructor(private router: Router) {

  }
  cards = [
    { icon: "fingerprint", head: "Create your brand", body: "Define your brand details to grow your sales.", color: "1" },
    { icon: "shop", head: "Create your store", body: "list your products to attract more customers.", color: "2" },
    { icon: "person", head: "Create your invoices", body: "estimate your total expenses before shopping.", color: "3" }
  ]
  clickCard() {
    this.router.navigateByUrl("/signUp")
  }
}
