import { Component } from '@angular/core';
import { InputDirective } from "../../Directives/input-directive";
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-home-page',
  imports: [InputDirective,],
  templateUrl: './home-page.html',
  styleUrl: './home-page.css'
})
export class HomePage {
  constructor(private router: Router) {

  }
  features = [
    { title: "Dark Mode", desc: "Enjoy a comfortable viewing experience with a smooth Dark Mode." },
    { title: 'Smart Expense Categorization', desc: 'Automatically categorize spending into meaningful categories so you understand where money goes.' },
    { title: 'Invoice ', desc: 'Create invoices manually to keep everything documented.', },
    { title: 'Detailed Reports', desc: 'Weekly and monthly charts and summaries to visualize your trends.', },
    { title: "Wide Product Range", desc: "Thousands of items to choose from." },
    { title: "No hidden fees", desc: "you always see the real price." }
  ];
  cards = [
    { icon: "fingerprint", head: "Create your brand", body: "Define your brand details to grow your sales." },
    { icon: "shop", head: "Create your store", body: "list your products to attract more customers." },
    { icon: "person", head: "Create your invoices", body: "estimate your total expenses before shopping." }
  ]
  clickCard() {
    this.router.navigateByUrl("/signUp")
  }
}
