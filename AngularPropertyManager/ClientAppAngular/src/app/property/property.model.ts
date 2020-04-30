export class Property {
  public id: string;
  public createdDateTime: Date;
  public address: Address;
  public purchasePrice: number;
  public purchaseDate: Date;

}

export class Address {
  public id: string;
  public createdDateTime: Date;
  public line1: string;
  public line2: string;
  public line3: string;
  public postCode: string;
  public city: string;
}
