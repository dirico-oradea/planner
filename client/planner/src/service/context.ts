import React from "react";
import { Service } from "./service";

export const ServiceGlobalContext = React.createContext<Service>(new Service());
