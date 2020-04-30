import { IUser } from "../../api-authorization/authorize.service";
import { Property } from "../property/property.model";

export class Portfolio {
  public name: string;
  public owner: IUser;
  public properties: Array<Property>;
}
