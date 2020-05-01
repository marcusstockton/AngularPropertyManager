import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { PropertyService } from '../property.service';
import { Property } from '../property.model';

@Component({
  selector: 'app-property-form',
  templateUrl: './property-form.component.html',
  styleUrls: ['./property-form.component.css']
})
export class PropertyFormComponent implements OnInit {
  private propertyId: string;

  constructor(private route: ActivatedRoute, private propertyService: PropertyService) { }

  ngOnInit() {
    this.route.paramMap.subscribe(params => {
      this.propertyId = params.get("propertyId")
      if (this.propertyId.length > 0) {
        this.propertyService.getPropertyById(this.propertyId).subscribe((data: Property) => {
          this.propertyForm.patchValue(data);
        }, (error) => {
            console.error(error);
        });
      }
    })
  }

  propertyForm = new FormGroup({
    id: new FormControl(""),
    purchasePrice: new FormControl(''),
    createdDateTime: new FormControl(''),
    updatedDateTime: new FormControl(''),
    address: new FormGroup({
      id: new FormControl(''),
      createdDateTime: new FormControl(''),
      updatedDateTime: new FormControl(''),
      line1: new FormControl(''),
      line2: new FormControl(""),
      line3: new FormControl(""),
      postCode: new FormControl(''),
      city: new FormControl("")
    })
  });

  onSubmit() {
    // TODO: Use EventEmitter with form value
    console.warn(this.propertyForm.value);
  }
}
