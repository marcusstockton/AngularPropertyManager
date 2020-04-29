export class Property {
  public Id: string;
  public CreatedDateTime: Date;
  public Address: Address;
  public PurchasePrice: number;
  public PurchaseDate: Date;

}

export class Address {
  public Id: string;
  public CreatedDateTime: Date;
  public Line1: string;
  public Line2: string;
  public Line3: string;
  public PostCode: string;
  public City: string;
}
