import { Base } from "../base.model";

export class Property extends Base {
  public address: Address;
  public purchasePrice: number;
  public purchaseDate: Date;
  public images: Array<File>;
}

export class Address extends Base {
  public line1: string;
  public line2: string;
  public line3: string;
  public postCode: string;
  public city: string;
}
