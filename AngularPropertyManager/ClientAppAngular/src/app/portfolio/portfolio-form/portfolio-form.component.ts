import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-portfolio-form',
  templateUrl: './portfolio-form.component.html',
  styleUrls: ['./portfolio-form.component.css']
})
export class PortfolioFormComponent implements OnInit {
  private portfolioId: string;
  constructor(private route: ActivatedRoute) {
    
  }

  ngOnInit() {
    this.route.paramMap.subscribe(params => {
      this.portfolioId = params.get("portfolioId")
    })
  }

}
