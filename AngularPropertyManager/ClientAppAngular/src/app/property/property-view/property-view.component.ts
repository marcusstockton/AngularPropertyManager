import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { PropertyService } from '../property.service';
import { Property } from '../property.model';

@Component({
  selector: 'app-property-view',
  templateUrl: './property-view.component.html',
  styleUrls: ['./property-view.component.css']
})
export class PropertyViewComponent implements OnInit {
  private propertyId: string;
  private property: Property;

  constructor(private route: ActivatedRoute, private propertyService: PropertyService) { }

  ngOnInit() {
    this.route.paramMap.subscribe(params => {
      this.propertyId = params.get("propertyId")
      this.propertyService.getPropertyById(this.propertyId).subscribe((data: Property) => {
        console.log(data);
        this.property = data;
      }, (error) => {
        console.log(error);
      });
    })
  }

}
