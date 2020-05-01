import { Component, OnInit } from '@angular/core';
import { PortfolioService } from '../portfolio.service';
import { Portfolio } from '../portfolio.model';

@Component({
  selector: 'app-portfolio-dashboard',
  templateUrl: './portfolio-dashboard.component.html',
  styleUrls: ['./portfolio-dashboard.component.css']
})
export class PortfolioDashboardComponent implements OnInit {
  public PortfolioList: Array<Portfolio>;
  constructor(private portfolioService: PortfolioService) { }

  ngOnInit() {
    this.portfolioService.getPortfolios().subscribe((data:Array<Portfolio>) => {
      this.PortfolioList = data;
    });
  }

}
