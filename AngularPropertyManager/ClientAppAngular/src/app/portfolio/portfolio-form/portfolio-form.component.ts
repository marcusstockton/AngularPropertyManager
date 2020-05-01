import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { FormGroup, FormControl } from '@angular/forms';
import { PortfolioService } from '../portfolio.service';
import { Portfolio } from '../portfolio.model';

@Component({
  selector: 'app-portfolio-form',
  templateUrl: './portfolio-form.component.html',
  styleUrls: ['./portfolio-form.component.css']
})
export class PortfolioFormComponent implements OnInit {
  private portfolioId: string;
  constructor(private route: ActivatedRoute, private portfolioService: PortfolioService) {
    
  }

  ngOnInit() {
    this.route.paramMap.subscribe(params => {
      this.portfolioId = params.get("portfolioId")
      if (this.portfolioId.length > 0) {
        this.portfolioService.getPortfolioById(this.portfolioId).subscribe((data: Portfolio) => {
          this.portfolioForm.setValue(data);
        }, (error) => {
          console.error(error)
        });
      }
    })
  }

  portfolioForm = new FormGroup({
    name: new FormControl(''),
  });

  onSubmit() {
    // TODO: Use EventEmitter with form value
    console.warn(this.portfolioForm.value);
  }
}
